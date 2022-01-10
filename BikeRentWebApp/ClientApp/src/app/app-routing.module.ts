import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BikesManagementComponent } from './components/bikes-management/bikes-management.component';

const routes: Routes = [
  { path: '', component: BikesManagementComponent }
]


@NgModule({
  imports: [RouterModule.forRoot(routes, { enableTracing: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
