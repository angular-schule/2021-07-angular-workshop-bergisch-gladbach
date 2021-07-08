import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDetailResolver } from './admin-detail/admin-detail-resolver';
import { AdminDetailComponent } from './admin-detail/admin-detail.component';
import { AdminDetailGuard } from './admin-detail/admin-detail.guard';
import { AdminComponent } from './admin.component';
import { AdminResolver } from './admin.resolver';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    resolve: {
      list: AdminResolver
    }
  },
  {
    path: ':id',
    component: AdminDetailComponent,
    canDeactivate: [AdminDetailGuard],
    resolve: {
      book: AdminDetailResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule {
}
