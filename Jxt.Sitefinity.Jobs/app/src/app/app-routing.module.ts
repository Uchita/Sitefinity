import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { JobsComponent } from './jobs/jobs.component';
import { JobDetailComponent } from './job-detail/job-detail.component';

const routes: Routes = [
	{ path: '', component: JobsComponent },
	{ path: 'edit/:id', component: JobDetailComponent },
	{ path: 'create', component: JobDetailComponent }
];

@NgModule({
	imports: [ RouterModule.forRoot(routes) ],
	exports: [ RouterModule ]
})

export class AppRoutingModule { }
