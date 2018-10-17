import { Injectable } from '@angular/core';
import { Job } from './job';
import { Observable } from 'rxjs';
import { of } from 'rxjs/observable/of';
import { MessageService } from './message.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
  
@Injectable()
export class JobService {

  baseUrl = '/jxt/jobsapi';
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private log(message: string): void{
	  this.messageService.add('Job.Service' + message);
  }
  
  private handleError<T> (operation = 'operation', result?: T) {
  return (error: any): Observable<T> => {
 
    console.error(error);
 
    this.log(`${operation} failed: ${error.message}`);
 
    return of(result as T);
  };
}
  
  getJobs(): Observable<Job[]>{
	  this.messageService.add('JobService: fetched jobs');
	  return this.http.get<Job[]>(this.baseUrl)
		.pipe(
			tap(jobs => this.log('fetched jobs')),
			catchError(this.handleError('getJobs',[]))
		);
  }
  
  getJob(id: string): Observable<Job>{
	  const url = this.baseUrl + '/' + id;
	  return this.http.get<Job>(url)
		.pipe(
		  tap(_ => this.log('fetched job id=${id}')),
		  catchError(this.handleError<Job>('getJob id=${id}'))
		);
  }
  
  createJob(job: Job): Observable<Job>{
	  return this.http.post(this.baseUrl+'/create', job, this.httpOptions)
		.pipe(
			tap((job: Job) => this.log('createJob')),
			catchError(this.handleError<Job>('crateJob failed'))
		);
  }
  
  updateJob(job: Job): Observable<any>{
	  return this.http.put(this.baseUrl+'/edit', job, this.httpOptions)
		.pipe(
			tap(_ => this.log('editJob')),
			catchError(this.handleError<any>('editJob failed'))
		);
  }
  
  deleteJob(job: Job): Observable<Job>{
	  return this.http.delete<Job>(this.baseUrl+'/delete/' + job.id, this.httpOptions)
			.pipe(
				tap(_ => this.log('deleteJob')),
				catchError(this.handleError<Job>('deleteDob failed'))
		);
  }

  constructor(private http: HttpClient, private messageService: MessageService) { }
  
}