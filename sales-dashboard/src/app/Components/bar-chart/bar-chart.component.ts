import { Component } from '@angular/core';
import Chart from 'chart.js/auto';
import { DashboardService } from 'src/app/dashboard.service';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent {
  public chart: any;
  public productsData: string[] = [];
  public salesData: number[] = [];
  constructor(private dashBoardService: DashboardService) {
  }
  
  ngOnInit(): void {
    this.loadChartData();
  }

  createChart() {
    this.chart = new Chart("MyChart", {
      type: 'bar', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: this.productsData, 
	       datasets: [
          {
            label: "Sales",
            data: this.salesData,
            backgroundColor: 'purple'
          }
        ]
      },
      options: {
        aspectRatio:2.5
      }
      
    });
  }

  private loadChartData(): void {
    this.dashBoardService.getSalesDataOfEachProductAcrossAllCitiesList()
    .subscribe((data:any) => {
      Promise.resolve().then(() => {
        if(data) {
          data.forEach((item:any) => {
            this.productsData.push(item?.product);
            this.salesData.push(item?.week_Total);
          })
        }
      }).then(() => {
        this.createChart();
      });
    })
  }
}
