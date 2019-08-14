import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { JobsComponent } from './jobs/jobs.component';
import { JobDetailComponent } from './job-detail/job-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { JobService } from './job.service';
import { MessageService } from './message.service';
import { AppRoutingModule } from './/app-routing.module';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    JobsComponent,
    JobDetailComponent,
    MessagesComponent
  ],
  imports: [
    BrowserModule,
	FormsModule,
	AppRoutingModule,
	HttpClientModule
  ],
  providers: [JobService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
