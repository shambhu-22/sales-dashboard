import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ModelData } from './Models/modeldata.model';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  apiUrl = environment.apiKey;
  constructor(private http: HttpClient) { }

  public getTopSoldMobileAcrossAllCitiesData(): Observable<any> {
    return this.http.get<any>(this.apiUrl + "/GetWeekTopSoldModelWithAmountAcrossCities");
  }

  public getTopSoldModelForEachCity(): Observable<any> {
    return this.http.get<any>(this.apiUrl + "/GetTopRankModelsSalesDataResult");
  }

  public getWeekLeastSoldModelWithAmountAcrossCities(): Observable<any> {
    return this.http.get<any>(this.apiUrl + "/GetWeekLeastSoldModelWithAmountAcrossCities");
  }

  public getWeekTotalSalesAcrossModelsAndCities(): Observable<any> {
    return this.http.get<any>(this.apiUrl + "/GetTotalWeekSalesAcrossAllModelsAndCities");
  }

  public getSalesDataOfEachProductAcrossAllCitiesList(): Observable<any> {
    return this.http.get<any>(this.apiUrl + "/GetSalesDataOfEachProductAcrossAllCitiesList");
  }
}
