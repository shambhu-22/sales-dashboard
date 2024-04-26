import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ModelData } from './Models/modeldata.model';
import { DashboardService } from './dashboard.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  public showTopModelWithAmount: boolean = false;
  public showLeastModelWithAmount: boolean = false;
  public topModelWithAmount: ModelData = new ModelData();
  public leastModelWithAmount: ModelData = new ModelData();
  public totalWeekSales: number = 0;
  public showTotalSales: boolean = false;
  public topProductDataPerCity: any = [];
  public showTopModelCityWise: boolean = false;
  public showBarChartData: boolean = false;
  public allModelsWithAmountData: ModelData[] = [];
  public chart: any;
  @ViewChild('barChart') myCanvas!: ElementRef<HTMLCanvasElement>;


  constructor(private service: DashboardService) {
  }

  public ngOnInit(): void {
    
  }


  public loadData(apiNumber: number) {
    if(apiNumber == 1) { // load top product with it's total sales
      this.showTopModelWithAmount = true;
      this.service.getTopSoldMobileAcrossAllCitiesData()
        .subscribe((data: any)  => {
        this.topModelWithAmount.Product = data.product;
        this.topModelWithAmount.Week_Total = data.week_Total;
      });
    } else if(apiNumber == 2) {
      this.showTopModelCityWise = true;
      this.service.getTopSoldModelForEachCity().subscribe((data: any) => {
        this.topProductDataPerCity = data;        
      });
    } else if(apiNumber == 3) {
      this.showLeastModelWithAmount = true;
      this.service.getWeekLeastSoldModelWithAmountAcrossCities().subscribe((data:any) => {
        this.leastModelWithAmount.Product = data.product;
        this.leastModelWithAmount.Week_Total = data.week_Total;
      });
    } else if(apiNumber == 4) {
      this.showTotalSales = true;
      this.service.getWeekTotalSalesAcrossModelsAndCities().subscribe((data: number) => {
        this.totalWeekSales = data;
      });
    } else if(apiNumber == 5) {
      this.showBarChartData = true;
      if(this.allModelsWithAmountData.length<1) {// reducing multiple db hits
        this.service.getSalesDataOfEachProductAcrossAllCitiesList()
        .subscribe((data:any) => {
        if(data) {
          data.forEach((element: any) => {
            let model = new ModelData();
            model.Product = element.product;
            model.Week_Total = element.week_Total;
            this.allModelsWithAmountData.push(model);
          });
        }
        })
      }
    }
  }

  public onModalClose() {
    // Function to execute when modal is closed
    this.showTopModelCityWise = false;
    this.showTopModelWithAmount = false;
    this.showLeastModelWithAmount = false;
    this.showTotalSales = false;
    this.showBarChartData = false;
  }

  

}
