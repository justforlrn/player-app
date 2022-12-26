export interface ClientHomeContent {
  Introduction: string;
  Indicators: [];
  TheGlobalMatrix: ChildTOC;
  UsingTheReportCard: ChildTOC;
}

export interface ChildTOC {
  Icon: string;
  Title: string;
  Content: string;
  Name: string;
}
