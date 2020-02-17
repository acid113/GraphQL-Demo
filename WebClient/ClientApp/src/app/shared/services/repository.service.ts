import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {

  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getData(route: string) {
    const url = this.createCompleteRoute(route, this.envUrl.urlAddress);
    console.log('url: ' + url);
    return this.http.get(url);
  }

  private createCompleteRoute(route: string, envAddress: string)
  {
    return `${envAddress}/${route}`;
  }

  // ! Make sure to enable Cors in GraphQL API
  private generateHeader() {
    return {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    };
  }

}
