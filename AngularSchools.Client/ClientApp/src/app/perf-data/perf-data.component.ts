import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-perf-data',
  templateUrl: './perf-data.component.html'
})
export class PerfDataComponent {
  public performances: Performance[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Performance[]>(baseUrl + 'perfdata').subscribe(result => {
      this.performances = result;
    }, error => console.error(error));
  }
}

interface Performance{
  initPerformance: number;
  jsonPerformance: number; 
  dapperPerformance: number;
  efPerformance: number;
  simPerformance: number;
  jsonPerformance2: number;
  dapperPerformance2: number;
  efPerformance2: number;
  simPerformance2: number;
  dapperUpdatePerformance: number;
  efUpdatePerformance: number;
  simUpdatePerformance: number;
  useSIM: number;
  useDapper: number;
  useEF: number;
  records: number;
  maxPage: number;
  allowDapper: number;
  allowEF: number;
 
}
