import { Component, OnInit } from '@angular/core';
import { Job } from '../job';
import { JobService } from '../job.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})

export class JobsComponent implements OnInit {
	jobs: Job[];
	selectedJob: Job;

  constructor(private jobService: JobService) { }

  ngOnInit() {
	  this.fetchJobs();
  }
  
  onSelect(job: Job): void{
	  this.selectedJob = job;
  }
  
  fetchJobs(): void{
	  this.jobService.getJobs()
		  .subscribe(jobs => this.jobs = jobs);
  }
  
}
