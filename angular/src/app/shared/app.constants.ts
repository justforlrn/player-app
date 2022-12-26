export type Language = 0 | 1;
export const constLanguage = {
  vi: 0,
  en: 1,
};
export interface ConstantLabels {
  LoginSuccessMessage: string;
}
export interface HeaderLabel {
  Home: string;
  ReportCard: string;
  AboutUs: string;
  Publications: string;
  Event: string;
}
export interface HomeLabels {
  Welcome: string;
  LatestAnnouncement: string;
  Introduction: string;
  Indicators: string;
}

export interface AppLabels {
  header: HeaderLabel;
  home: HomeLabels;
  constants: ConstantLabels;
}
export const enLabels: AppLabels = {
  header: {
    Home: 'Home',
    ReportCard: 'Report Card',
    AboutUs: 'About Us',
    Publications: 'Publications',
    Event: 'Event',
  },
  home: {
    Welcome: 'Welcome to Active Healthy Kids Viet Nam',
    LatestAnnouncement: 'Latest Announcement',
    Introduction: 'INTRODUCTION',
    Indicators: 'Indicators',
  },
  constants: {
    LoginSuccessMessage: 'Login success',
  },
};
export const viLabels: AppLabels = {
  header: {
    Home: 'Trang chủ',
    ReportCard: 'Báo cáo',
    AboutUs: 'Về chúng tôi',
    Publications: 'Ấn phẩm',
    Event: 'Sự kiện',
  },
  home: {
    Welcome: 'Chào mừng đến với Active Healthy Kids Việt Nam',
    LatestAnnouncement: 'Thông báo mới nhất',
    Introduction: 'Giới thiệu',
    Indicators: 'Chỉ số',
  },
  constants: {
    LoginSuccessMessage: 'Đăng nhập thành công',
  },
};
