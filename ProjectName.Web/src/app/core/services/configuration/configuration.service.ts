import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IConfiguration } from '../../interfaces/iconfiguration';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {
  private configuration: IConfiguration;
  constructor(private http: HttpClient) {
  }

  loadAppConfig() {
    const promise: Promise<IConfiguration> = this.http.get<IConfiguration>("/assets/appsettings.json")
      .toPromise()
      .then(data => {
        this.configuration = data;
        return data;
      });

    return promise;
  }

  get apiUrl(): string {
    return `${this.configuration.AppSettings.ApiUrl}`;
  }

}
