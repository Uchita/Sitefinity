import { Component, OnInit, Input } from '@angular/core';
import { Job } from '../job';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { JobService } from '../job.service';

@Component({
  selector: 'app-job-detail',
  templateUrl: './job-detail.component.html',
  styleUrls: ['./job-detail.component.css']
})
export class JobDetailComponent implements OnInit {
  
  job: Job
  isNew: boolean

  constructor(
	  private route: ActivatedRoute,
	  private jobService: JobService,
	  private location: Location
	) 
	{	
	  this.isNew = true;
	}

  ngOnInit() {

    let id : string = this.route.snapshot.paramMap.get('id');
	  if(id){
		  this.isNew = false;
		  this.fetchJob(id);
	  }
	  else{
		  this.job = new Job();
	  }
  }
  
  fetchJob(id: string): void{
	  this.jobService.getJob(id)
	    .subscribe(job => this.job = job);
  }
  
  save(): void{
	  if(this.isNew){
		  this.jobService.createJob(this.job)
		    .subscribe(() => this.goBack());
	  }
	  else{
		  this.jobService.updateJob(this.job)
		    .subscribe(() => this.goBack());
	  }
	  
	  this.goBack();
  }
  
  goBack(): void{
	  this.location.back();
  }
}
