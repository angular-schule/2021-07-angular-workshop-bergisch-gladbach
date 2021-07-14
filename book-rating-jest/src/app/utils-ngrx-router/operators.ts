/* eslint-disable prefer-arrow/prefer-arrow-functions */
import { BaseRouterStoreState, ROUTER_NAVIGATED, RouterAction, RouterNavigatedAction } from '@ngrx/router-store';
import { MonoTypeOperatorFunction, OperatorFunction, pipe } from 'rxjs';
import { distinctUntilChanged, filter, map } from 'rxjs/operators';

import { CustomRouterStateSnapshot } from './serializer';

/**
 * Helper predicate function factory that determines whether
 * a route matches the given path(s).
 * Should usually never be used directly, but always through the `ofRoute` operator.
 * @param route route path(s) to check. Can be a single path, an array of paths or a RegEx
 */
export function isRoute(route: string | string[] | RegExp) {
  return (
    action: RouterAction<
      RouterNavigatedAction<CustomRouterStateSnapshot>,
      CustomRouterStateSnapshot
    >
  ) => {
    const isRouteAction = action.type === ROUTER_NAVIGATED;
    if (isRouteAction) {
      const routePath = action.payload.routerState.path;
      if (Array.isArray(route)) {
        return route.indexOf(routePath) > -1;
      } else if (route instanceof RegExp) {
        return route.test(routePath);
      } else {
        return routePath === route;
      }
    }
    return isRouteAction;
  };
}

/**
 * RxJS operator to filter for certain routes.
 * Should be used in NgRx effects to only continue the pipeline for the given rout path(s).
 * @param route route path(s) to check. Can be a single path, an array of paths or a RegEx
 */
export function ofRoute<T extends BaseRouterStoreState>(
  route: string | string[] | RegExp
//): MonoTypeOperatorFunction<RouterNavigatedAction<T>> {
): any {
  {
    return filter<RouterNavigatedAction<any>>(isRoute(route));
  }
}

/**
 * RxJS operator to extract the *whole* params object from a route action.
 * Should be used in NgRx effects, usually after the `ofRoute` operator.
 * ```
 * // Usage example
 * this.actions$.pipe(
 *   ofRoute('foo/:bar'),
 *   mapToParams(),
 *   tap(params => console.log(params.bar))
 * )
 * ```
 */
export function mapToParams() {
  return map(
    (
      action: RouterAction<
        RouterNavigatedAction<CustomRouterStateSnapshot>,
        CustomRouterStateSnapshot
      >
    ) => action.payload.routerState.params
  );
}

/**
 * RxJS operator to extract a *single* route param from a route action.
 * Should be used in NgRx effects, usually after the `ofRoute` operator.
 * ```
 * // Usage example
 * this.actions$.pipe(
 *   ofRoute('foo/:bar'),
 *   mapToParam('bar'),
 *   tap(bar => console.log(bar))
 * )
 * ```
 */
export function mapToParam(
  paramName: string
): OperatorFunction<
  RouterAction<
    RouterNavigatedAction<CustomRouterStateSnapshot>,
    CustomRouterStateSnapshot
  >,
  string
> {
  return pipe(
    mapToParams(),
    map(params => params[paramName]),
    distinctUntilChanged()
  );
}

/**
 * RxJS operator to extract the *whole* query params object from a route action.
 * Should be used in NgRx effects, usually after the `ofRoute` operator.
 * ```
 * // Usage example
 * this.actions$.pipe(
 *   ofRoute('foo'),
 *   mapToQueryParams(),
 *   tap(params => console.log(params.sort))
 * )
 * ```
 */
export function mapToQueryParams() {
  return map(
    (
      action: RouterAction<
        RouterNavigatedAction<CustomRouterStateSnapshot>,
        CustomRouterStateSnapshot
      >
    ) => action.payload.routerState.root.queryParams
  );
}

/**
 * RxJS operator to extract a *single* query param from a route action.
 * Should be used in NgRx effects, usually after the `ofRoute` operator.
 * ```
 * // Usage example
 * this.actions$.pipe(
 *   ofRoute('foo'),
 *   mapToQueryParam('sort'),
 *   tap(sort => console.log(sort))
 * )
 * ```
 */
export function mapToQueryParam(
  paramName: string
): OperatorFunction<
  RouterAction<
    RouterNavigatedAction<CustomRouterStateSnapshot>,
    CustomRouterStateSnapshot
  >,
  string
> {
  return pipe(
    mapToQueryParams(),
    map(params => params[paramName]),
    distinctUntilChanged()
  );
}
