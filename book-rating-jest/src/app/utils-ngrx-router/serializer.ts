import {
  RouterStateSerializer,
  MinimalRouterStateSerializer,
  MinimalRouterStateSnapshot,
} from '@ngrx/router-store';
import {
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
  Params,
} from '@angular/router';

export interface CustomRouterStateSnapshot extends MinimalRouterStateSnapshot {
  path: string;
  params: Params;
}

export class CustomRouterStateSerializer extends MinimalRouterStateSerializer
  implements RouterStateSerializer<CustomRouterStateSnapshot> {
  constructor() {
    super();
  }

  serialize(routerState: RouterStateSnapshot): CustomRouterStateSnapshot {
    const serializedRoute = super.serialize(routerState);
    const routeInfo = this.getRouteInfo(routerState.root);

    return {
      ...serializedRoute,
      ...routeInfo,
    };
  }

  private getRouteInfo(
    route: ActivatedRouteSnapshot
  ): { path: string; params: Params } {
    const path: string[] = [];
    let params = {};

    while (route) {
      if (route.routeConfig && route.routeConfig.path) {
        path.push(route.routeConfig.path);
      }
      // params must be collected throughout all route segments
      if (route.params) {
        params = { ...params, ...route.params };
      }

      route = route.firstChild as any;
    }

    return {
      path: path.join('/'),
      params,
    };
  }
}
