import { Injectable } from '@angular/core';
import { AboutUs } from '../client/modules/about-us/about-us.model';
import { ClientHomeContent } from '../client/modules/client-home/client-home.model';
import { ReportCard } from '../client/modules/report-cards/report-card.model';
import { constLanguage, enLabels, Language, viLabels } from './app.constants';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  public _language: Language = 0;
  constructor() {
    this.language;
  }
  get language() {
    let localLanguage = localStorage.getItem('language');
    if (localLanguage == null) {
      localStorage.setItem('language', this._language.toString());
    } else {
      if(localLanguage == 'en') {
        localLanguage = '1';
        localStorage.setItem('language', localLanguage);
      }
      else if (localLanguage == 'vi') {
        localLanguage = '0';
        localStorage.setItem('language', localLanguage);
      }
      this._language = parseInt(localLanguage) as Language;
    }
    switch (this._language) {
      case constLanguage.vi: {
        return viLabels;
      }
      case constLanguage.en: {
        return enLabels;
      }
      default: {
        return enLabels;
      }
    }
  }
  switchLanguage(language: Language) {
    localStorage.setItem('language', language.toString());
    window.location.reload();
    return this.language;
  }

  demo_getHomePage() {
    let localLanguage = this._language;
    if (localLanguage == constLanguage.en) {
      let data: ClientHomeContent = {
        Introduction:
          'Established in 2015, Active Healthy Kids Hong Kong consists of researchers and practitioners in the area of physical activity and health who have collaborated with stakeholders to produce Hong Kong’s Report Cards on physical activity for children and youth. The Active Healthy Kids Hong Kong Report Card is an evidence-based synthesis on physical activity behaviors in children and youth, based on the best available evidence across a series of indicators related to individual behaviors, settings and sources of influence, and strategies and investments. The evidence is evaluated and interpreted by an expert consensus panel, resulting in the assignment of a letter “grade”. The report card aims to consolidate existing evidence, facilitate international comparisons, encourage more evidence-informed physical activity and health policies, improve surveillance of physical activity and most importantly, to promote and facilitate opportunities for physical activity among children and youth in Hong Kong.',
        Indicators: [],
        TheGlobalMatrix: {
          Icon: 'tdsi-shine-fill',
          Title: 'The “Global Matrix"',
          Content:
            'The Hong Kong Report Card is part of a global effort to promote physical activity in children and youth (Active Healthy Kids Global Alliance, AHKGA). In November 2016, the results of the first Hong Kong Report Card were published in conjunction with the results from 37 other countries and regions (known as “Global Matrix 2.0”) at an international conference. The update of report card results is usually conducted every two to three years. The Global Matrix 3.0 consisting of Report Cards from 49 countries and regions including Hong Kong was launched at the Movement to Move Conference in November 2018.',
          Name: 'TheGlobalMatrix',
        },
        UsingTheReportCard: {
          Icon: 'tdsi-shine-fill',
          Title: 'Using the Report Card',
          Content:
            'The report card provides the most recent, relevant and critical information on physical activity and health of children and youth in Hong Kong, and its generated findings can be used in a number of ways:<br> <div class="pl-8"> <li>Government: For policy development and investment decisions.</li> <li>Researchers/academics: To enhance student learning, identify new research areas and inform grant applications.</li> <li>Teachers, coaches, and allied health professionals, charitable organizations: For professional development and inform decision making.</li> <li>Funding bodies: For funding strategy and inform decision making.</li> </div>',
          Name: 'UsingTheReportCard',
        },
      };
      return data;
    } else {
      let data: ClientHomeContent = {
        Introduction:
          'Được thành lập vào năm 2015, Active Healthy Kids Hong Kong bao gồm các nhà nghiên cứu và học viên trong lĩnh vực hoạt động thể chất và sức khỏe, những người đã hợp tác với các bên liên quan để tạo ra các Phiếu báo cáo của Hong Kong về hoạt động thể chất cho trẻ em và thanh thiếu niên. Thẻ báo cáo Active Healthy Kids Hong Kong là một tổng hợp dựa trên bằng chứng về hành vi hoạt động thể chất ở trẻ em và thanh thiếu niên, dựa trên bằng chứng tốt nhất hiện có về một loạt các chỉ số liên quan đến hành vi cá nhân, môi trường và nguồn ảnh hưởng cũng như chiến lược và đầu tư. Bằng chứng được đánh giá và giải thích bởi một hội đồng đồng thuận chuyên gia, dẫn đến việc chỉ định một chữ cái "điểm". Thẻ báo cáo nhằm mục đích củng cố bằng chứng hiện có, tạo điều kiện so sánh quốc tế, khuyến khích các chính sách y tế và hoạt động thể chất dựa trên bằng chứng, cải thiện việc giám sát hoạt động thể chất và quan trọng nhất là thúc đẩy và tạo điều kiện cho trẻ em và thanh thiếu niên ở Hồng Kông có cơ hội hoạt động thể chất.',
        Indicators: [],
        TheGlobalMatrix: {
          Icon: 'tdsi-shine-fill',
          Title: '“Ma trận toàn cầu”',
          Content:
            'Thẻ Báo cáo Hồng Kông là một phần trong nỗ lực toàn cầu nhằm thúc đẩy hoạt động thể chất ở trẻ em và thanh thiếu niên (Active Healthy Kids Global Alliance, AHKGA). Vào tháng 11 năm 2016, kết quả của Thẻ báo cáo Hồng Kông đầu tiên đã được công bố cùng với kết quả từ 37 quốc gia và khu vực khác (được gọi là “Ma trận toàn cầu 2.0”) tại một hội nghị quốc tế. Việc cập nhật kết quả học bạ thường được tiến hành hai đến ba năm một lần. Ma trận Toàn cầu 3.0 bao gồm các Phiếu báo cáo từ 49 quốc gia và khu vực bao gồm cả Hồng Kông đã được ra mắt tại Hội nghị Chuyển động để Chuyển động vào tháng 11 năm 2018.',
          Name: 'TheGlobalMatrix',
        },
        UsingTheReportCard: {
          Icon: 'tdsi-shine-fill',
          Title: 'Sử dụng Thẻ báo cáo',
          Content:
            'Thẻ báo cáo cung cấp thông tin quan trọng, có liên quan và mới nhất về hoạt động thể chất cũng như sức khỏe của trẻ em và thanh thiếu niên ở Hồng Kông, đồng thời những phát hiện được tạo ra có thể được sử dụng theo một số cách:<br> <div class="pl-8" > <li>Chính phủ: Dành cho các quyết định đầu tư và phát triển chính sách.</li> <li>Các nhà nghiên cứu/học giả: Để nâng cao việc học tập của sinh viên, xác định các lĩnh vực nghiên cứu mới và thông báo cho các đơn xin tài trợ.</li> <li>Giáo viên, huấn luyện viên và các chuyên gia y tế đồng minh, các tổ chức từ thiện: Để phát triển chuyên môn và cung cấp thông tin cho quá trình ra quyết định.</li> <li>Các cơ quan cấp vốn: Cho chiến lược tài trợ và cung cấp thông tin cho quá trình ra quyết định.</li> </div>',
          Name: 'UsingTheReportCard',
        },
      };
      return data;
    }
  }

  demo_getReportCard() {
    let localLanguage = this._language;
    if (localLanguage == constLanguage.vi) {
      let data: ReportCard = {
        PageTitle:
          '<span class="text-green-500">Báo cáo về</span><br> <span class="text-4xl text-orange-500"> VẬN ĐỘNG THỂ LỰC Ở TRẺ EM VÀ TRẺ VỊ THÀNH NIÊN VIỆT NAM 2022 </span>',
        PageContent:
          '<div class="py-4">Báo cáo này được thực hiện để phản ánh thực trạng và mô tả các yếu tố quyết định đến vận động thể lực và sức khỏe ở trẻ em và trẻ vị thành niên Việt Nam từ 6 đến 17 tuổi. Dữ liệu trong báo cáo này được tổng hợp từ các nghiên cứu trên cả nước. Tiêu chí đánh giá trong bản báo cáo này được xây dựng bởi Active Healthy Kids Global Alliance, cụ thể như sau: <img src="assets/imgs/report-cards/vi-table-1.png" class="h-[500px] m-auto py-4" /> Phân loại đánh giá các tiêu chí được xác định dựa trên tỉ lệ trẻ em và trẻ vị thành niên Việt Nam hoặc các đối tượng nghiên cứu đạt được đáp ứng yêu cầu của tiêu chí đó. Những tiêu chí này phản ánh thực trạng về vận động thể lực ở trẻ em và trẻ vị thành niên Việt Nam. Bản báo cáo này có giá trị cung cấp thông tin giúp xây dựng những chính sách phù hợp để nâng cao tình trạng vận động thể lực ở trẻ em và trẻ vị thành niên trong gia đình, nhà trường, cộng đồng và cả nước nói chung. <img src="assets/imgs/report-cards/vi-table-2.png" class="h-[400px] m-auto py-4" /></div> <div class="py-4"> <h2 class="font-semibold">1. Tình hình vận động thể lực chung: F</h2> <p class="pl-4"> Chưa đến 20% trẻ em và trẻ vị thành niên Việt Nam đạt được khuyến cáo của Tổ chức Y tế Thế giới về vận động thể lực, cụ thể là 60 phút vận động ở cường độ vừa đến mạnh mỗi ngày. Dữ liệu được tính dựa trên kết quả của ba nghiên cứu đã được công bố. (Ngan HTD và cộng sự, 2018; To QG và cộng sự, 2020; Tổ chức Y tế Thế giới, 2013) </p> </div> <div> <h2 class="font-semibold">2. Thể thao và Vận động thể lực có tổ chức: INC</h2> <p class="pl-4">Dữ liệu về thể thao và vận động thể lực có tổ chức được thu thập "Báo cáo khảo sát hành vi sức khỏe học sinh toàn cầu tại Việt Nam năm 2013(Global School Health Survey – GSHS) (Tổ chức Y tế Thế giới, 2013) nhưng không được công bố.</p> </div> <div> <h2 class="font-semibold">3. Các hoạt động vui chơi chủ động: INC</h2> <p class="pl-4"> Không có dữ liệu có tính đại diện để đánh giá tiêu chí Vui chơi chủ động. </p> </div> <div> <h2 class="font-semibold">4. Đi bộ hoặc đi xe đạp tới trường: D+</h2> <p class="pl-4"> Khoảng 35% học sinh Việt Nam sử dụng các phương tiện di chuyển chủ động (đi bộ hoặc đạp xe) để đến trường. (Tổ chức Y tế Thế giới, 2013) </p> </div> <div> <h2 class="font-semibold">5. Hành vi tĩnh tại: C-</h2> <p class="pl-4"> Chỉ có khoảng 40% trẻ em và trẻ vị thành niên Việt Nam sử dụng màn hình điện tử (điện thoại, ti vi, máy tính, v.v...) dưới 2 giờ mỗi ngày. (Kim TV và cộng sự, 2022; Ngan HTD và cộng sự, 2018; Trang NHHD và cộng sự, 2013) Tổng thời gian ngồi yên của trẻ là rất cao, khoảng 11,5 giờ mỗi ngày. (Trang NHHD và cộng sự, 2013) </p> </div> <div> <h2 class="font-semibold">6. Thể lực: INC</h2> <p class="pl-4"> Không có dữ liệu đại diện cho nhóm tuổi này tạiViệt Nam. </p> </div> <div> <h2 class="font-semibold">7. Sự ủng hộ từ gia đình và bạn đồng trang lứa: C</h2> <p class="pl-4"> Trong năm 2015, có 84,1% người lớn độ tuổi từ 18 đến 69 đạt được khuyến cáo về vận động ở mức cao (ít nhất 1.500 MET-phút mỗi tuần); và 19,7% đạt khuyến cáo về vận động ở mức trung bình (ít nhất 600 MET-phút mỗi tuần). (Cục Y tế Dự phòng, 2015) Khoảng 24,5% gia đình có vận động thể lực đủ, và 86% xã, phường, thị trấn trên cả nước tổ chức ngày chạy. (Tổng cục Thể dục Thể thao, 2019) Theo khảo sát, chỉ có 58% nhân viên y tế tham gia trả lời rằng vận động thể lực đóng vai trò quan trọng trong công tác chăm sóc sức khỏe; 36% cho rằng vận động thể lực có phần quan trọng, và đến 6% cho rằng vận động thể lực là không quan trọng. (Beckvid-Henriksson và cộng sự, 2018). Tỉ lệ dùng để đánh giá tiêu chí Gia đình được tính từ ba nghiên cứu nêu trên. </p> </div> <div> <h2 class="font-semibold">8. Môi trường vận động trong trường học: A</h2> <p class="pl-4"> Theo báo cáo kết quả thực hiện Nghị quyết về Tăng cường thể dục thể thao đến năm 2020, 100% các trường tiểu học và trung học (trẻ từ 6 đến 17 tuổi) có hai tiết giáo dục thể chất mỗi tuần (mỗi tiết dài 45 phút). (Bộ Giáo dục và Đào tạo, 2021) Môn giáo dục thể chất được thiết kế phù hợp với từng đối tượng học sinh, và 100% giáo viên dạy môn này tham gia lớp đào tạo huấn luyện về phương pháp giảng dạy. (Bộ Giáo dục và Đào tạo, 2021) Tuy nhiên, chỉ có 59% số trường THCS và THPT có sân chơi thể thao (ví dụ sân bóng đá, nhà thể chất,...) (Tổ chức Y tế Thế giới, 2013) </p> </div> <div> <h2 class="font-semibold">9. Sự ủng hộ từ cộng đồng và các yếu tố môi trường ảnh hưởng đến vận động thể lực: C</h2> <p class="pl-4"> Chưa đến 50% khu dân cư tại hai thành phố lớn là Hà Nội và Thành phố Hồ Chí Minh có khu vui chơi hay công viên. (Hoang AT và cộng sự, 2019; Pham TTH và cộng sự, 2019) </p> </div> <div> <h2 class="font-semibold">10. Chính sách của Nhà nước về vận động thể lực ở trẻ em: B-</h2> <p class="pl-4"> Để triển khai nghị định của Chính phủ và các đề án phát triển giáo dục thể chất, thể thao trường học, Vụ Giáo dục Thể chất (Bộ GD&ĐT) đã kí kết hợp tác với các đơn vị liên quan để tổ chức các hoạt động truyền thông về thể thao trường học giai đoạn 2020-2025. Chuỗi hoạt động gồm các chương trình truyền hình thể thao trường học; giải đấu thể thao thường niên; cung cấp bộ học liệu chuẩn cho giáo viên và học sinh cả nước. (Bộ Giáo dục và Đào tạo, 2020)</p> </div> <div> <h2 class="font-semibold">11. Tình trạng béo phì: B-</h2> <p class="pl-4"> Trong bản báo cáo của UNICEP dựa trên Khảo sát Dinh dưỡng Quốc gia Việt Nam 2020, kết quả cho thấy có 19% trẻ em và trẻ vị thành niên tuổi từ 5 đến 19 bị thừa cân hoặc béo phì. (Bộ Y tế, 2021) Kết quả từ một nghiên cứu khác trên cùng bộ dữ liệu cho thấy có 14,8% trẻ từ 5 đến 19 tuổi bị suy dinh dưỡng. (UNICEF, 2021) Từ những dữ liệu trên, chúng tôi ước tính rằng có khoảng 66,2% trẻ em và trẻ vị thành niên Việt Nam có cân nặng trong mức khỏe mạnh, dù không có số liệu phân tích trực tiếp. Do đó, chỉ số này được phân loại ở mức B-. </p> </div>',
      };
      return data;
    } else {
      let data: ReportCard = {
        PageTitle:
          '<span class="text-green-500">The 2022 Viet Nam Report Card on</span><br> <span class="text-4xl text-orange-500"> PHYSICAL ACTIVITY FOR CHILDREN AND ADOLESCENTS </span>',
        PageContent:
          '<div class="py-4">This report card provides an assessment of the current state and determinants of physical activity (PA) and physical health in Vietnamese children and adolescents aged 6 to 17 years. This is a national report card. Grades were determined using the methods developed by Active Healthy Kids Global Alliance. The card grades are determined by the percentage of Vietnamese children and adolescents meeting the benchmark for each indicator: <img src="assets/imgs/report-cards/en-table-1.png" class="h-[500px] m-auto py-4" /> The grades illustrate the state of physical activity in Vietnamese children and adolescents. The report card can be utilized to support policy development to increase physical activity in children and adolescents in within families, in schools, local communities, and the country as a whole. <img src="assets/imgs/report-cards/en-table-2.png" class="h-[400px] m-auto py-4" /></div> <div class="py-4"> <h2 class="font-semibold">1. Overall Physical Activity: F</h2> <p class="pl-4"> Less than 20% of Vietnamese children and adolescents met the global recommendations of at least 60 min of moderate-to-vigorous physical activity (MVPA) a day. Data was averaged from three studies. (Ngan et al., 2018; To et al., 2020; World Health Organization, 2013) </p> </div> <div> <h2 class="font-semibold">2. Organized Sport and Physical Activity: INC</h2> <p class="pl-4"> Data regarding Organized Sport was collected in the Global School Health Survey (World Health Organization, 2013) but was not accessible to the research team. </p> </div> <div> <h2 class="font-semibold">3. Active Play: INC</h2> <p class="pl-4"> Less than 20% of Vietnamese children and adolescents There are no nationally representative data for active and outdoor play. </p> </div> <div> <h2 class="font-semibold">4. Active Transport: D+</h2> <p class="pl-4"> Around 35% of Vietnamese students use active transport methods (walk or bike) to travel to and from school. (World Health Organization, 2013) </p> </div> <div> <h2 class="font-semibold">5. Sedentary Behaviour: C-</h2> <p class="pl-4"> On average, 40% of Vietnamese children and adolescents had less than 2 hours of screen time in a typical day. (Kim et al., 2022; Ngan et al., 2018; Trang et al., 2013) Total daily sitting time (not limited to screen time) was very high, around 11.5 hours. (Trang et al., 2013) </p> </div> <div> <h2 class="font-semibold">6. Physical Fitness: INC</h2> <p class="pl-4"> There are no representative Vietnamese data for Physical Fitness. </p> </div> <div> <h2 class="font-semibold">7. Family and Peers: C</h2> <p class="pl-4"> In 2015, 84.1% of the adult population aged 18 to 69 years met the criteria for being highly physically active (at least 1,500 MET-minutes per week); and 19.7% achieved moderate levels of physical activity (at least 600 MET-minutes per week). (Department of Preventive Medicine, 2015) About 24.5% of households were physically active, and 86% of local districts organised a "Running Day" in their communities. (Directorate of Sports and Exercise, 2019) Only 58% of surveyed healthcare professionals agreed that PA was very important for health; 36% thought PA was somewhat important while 6% said PA was not important. (Beckvid-Henriksson et al., 2018) Proportions were averaged across these three studies to inform the Family indicator grading. </p> </div> <div> <h2 class="font-semibold">8. Schools: A</h2> <p class="pl-4"> Resolution on Improving Physical Education and Sport 2011-2020 reported that 100% of primary and high schools (children aged 6 to 17) had 2 physical education (PE) sessions (45 mins each) per week. (Ministry of Education and Training, 2021) PE was tailored to individual physical ability and age groups, and 100% of PE teachers attended annual training and a workshop on physical education. (Ministry of Education and Training, 2021) However, only 59% of secondary (children aged 11 to 15) and high schools (children aged 15 to 18) have sports grounds (soccer field, gymnastic hall etc). (World Health Organization, 2013) </p> </div> <div> <h2 class="font-semibold">9. Community and Environment: C</h2> <p class="pl-4"> In two major citites, Ho Chi Minh City and Ha Noi, less than 50% of Vietnamese children and adolescents have access to parks or playgrounds. (Hoang et al., 2019; Pham et al., 2019) </p> </div> <div> <h2 class="font-semibold">10. Government: B-</h2> <p class="pl-4"> As a part of the national plan for creating a healthy school environment 2020-2025, a social media campaign will be developed between 2021-2025 to promote sport events at schools; annual sport tournaments across schools; and provide educational materials for students and PE teachers national wide. (Ministry of Education and Training, 2020) There were no further community-based public health initiatives to promote PA in children and adolescents outside of the school setting. </p> </div> <div> <h2 class="font-semibold">11. Obesity: B-</h2> <p class="pl-4"> A report by UNICEF based on the National Nutrition Survey in Viet Nam in 2020 showed that 19% of children aged 5-19 years were overweight and obese. (Minnistry of Health, 2021) Another analysis of the same data set reported that 14.8% of children and adolescents (aged 5 to 19 years) were underweight. (UNICEF 2021) We did not have the direct prevalence; however, the data were sufficient to estimate 66.2% of children and adolescents had a healthy weight, making this new indicator grading B-. </p> </div>',
      };
      return data;
    }
  }

  demo_getAboutUs() {
    let localLanguage = this._language;
    if (localLanguage == constLanguage.en) {
      let data: AboutUs = {
        AHKGA: {
          Title: 'Active Healthy Kids Global Alliance',
          Content:
            'The Active Healhy Kids Global Alliance is a network of researchers, health professionals, and stakeholders who work together to advance physical activity in children and youth from around the world. Officially established in 2014, with the history of work started from 2005, the Alliance and its partners worldwide has put in enormous and continuing efforts towards the mission for a world of active healthy kids. Active Healthy Kids Global Alliance website: <a class="text-green-500 hover:underline" href=""https://www.activehealthykids.org/"">https://www.activehealthykids.org/</a>',
        },
        VNTeam: {
          Title: 'Viet Nam Team',
          Content:
            'In Viet Nam, 2022 is the first year that a group of researchers was gathered to compose the Viet Nam Report Card on Physical Activity for Children and Youth. Our next step is to establish the Active Healthy Kids Viet Nam Working Group to monitor the progress of Viet Nam on these indicators. The next update is due in 2024-2025.',
        },
        ListAuthor: {
          Title: 'List of authors of the 2022 Viet Nam Report Card:',
          Content:
            '<div> <li class="font-semibold">Phuong Nguyen, MPH</li> <p class="pl-6">Deakin Health Economics, Institute for Health Transformation<br> Deakin University, Geelong, Victoria, Australia<br> <a href="mailto: phuong.nguyen@deakin.edu.au" class="text-blue-500 hover:underline">Email: phuong.nguyen@deakin.edu.au</a></p> </div> <div> <li class="font-semibold">Dan Xuan Nguyen, MD</li> <p class="pl-6">Department of Epidemiology, Faculty of Public Health<br> Pham Ngoc Thach University of Medicine, Ho Chi Minh City, Viet Nam<br> <a href="mailto: dannx@pnt.edu.vn" class="text-blue-500 hover:underline">Email: dannx@pnt.edu.vn</a></p> </div> <div> <li class="font-semibold">Long Khanh-Dao Le, PhD</li> <p class="pl-6">Health Economics Division, School of Public Health and Preventive Medicine<br> Monash University, Melbourne, Australia</p> </div> <div> <li class="font-semibold">Jaithri Ananthapavan, MPH</li> <p class="pl-6">Deakin Health Economics, Institute for Health Transformation<br> Deakin University, Geelong, Victoria, Australia </p> </div> <div> <li class="font-semibold">Phan Danh Na, MBA</li> <p class="pl-6">Department of Sport Management<br> National Taiwan University of Sport, Taichung City, Taiwan </p> </div> <div> <li class="font-semibold">Assoc. Prof. Hong K. Tang, MD, PhD</li> <p class="pl-6">Department of Epidemiology, Faculty of Public Health<br> Pham Ngoc Thach University of Medicine, Ho Chi Minh City, Viet Nam </p> </div>',
        },
      };
      return data;
    } else {
      let data: AboutUs = {
        AHKGA: {
          Title: 'Active Healthy Kids Global Alliance',
          Content:
            'Active Healthy Kids Global Alliance là một mạng lưới liên kết các nhà nghiên cứu, nhân viên y tế, các cá nhân, tổ chức trong các lĩnh vực liên quan để hợp tác nghiên cứu và triển khai các đề án nhằm nâng cao tình hình vận động thể lực ở trẻ em và trẻ vị thành niên trên toàn thế giới. Những hoạt động đầu tiên của tổ chức này bắt đầu từ năm 2005 và được chính thức thành lập vào năm 2014. Từ đó đến nay, Active Healthy Kids Global Alliance và các đối tác đã nỗ lực không ngừng nghỉ cho sứ mệnh xây dựng một thế hệ trẻ năng động và khỏe mạnh. Trang web chính thức của tổ chức Active Healthy Kids Global Alliance: <a class="text-green-500 hover:underline" href="https://www.activehealthykids.org/">https://www.activehealthykids.org/</a>',
        },
        VNTeam: {
          Title: 'Nhóm tác giả tại Việt Nam',
          Content:
            'Nhóm tác giả của Báo cáo về Vận động thể lực ở Trẻ em và Trẻ vị thành niên Việt Nam 2022 gồm các nhà nghiên cứu y tế công cộng đến từ các trường Đại học tại Việt Nam, Úc và Đài Loan. Đây là bản báo cáo đầu tiên được thực hiện tại Việt Nam, và chúng tôi sẽ hướng đến việc thành lập Nhóm Công tác chính thức để theo dõi sự thay đổi của các chỉ số trong tương lai. Bản báo cáo cập nhật dự kiến được phát hành vào khoảng năm 2024-2025.',
        },
        ListAuthor: {
          Title: 'Nhóm tác giả:',
          Content:
            '<div> <li class="font-semibold">ThS. Phuong Nguyen</li> <p class="pl-6">Bộ môn Kinh tế Y tế, Trường Phát triển Sức khỏe và Xã hội<br> Đại học Deakin, Geelong, Victoria, Úc<br> <a href="mailto: phuong.nguyen@deakin.edu.au" class="text-blue-500 hover:underline">Email: phuong.nguyen@deakin.edu.au</a> </p> </div> <div> <li class="font-semibold">BS. Nguyễn Xuân Đan</li> <p class="pl-6">Bộ môn Dịch tễ học, Khoa Y tế Công cộng<br> Trường Đại học Y khoa Phạm Ngọc Thạch, TP. Hồ Chí Minh, Việt Nam<br> <a href="mailto: dannx@pnt.edu.vn" class="text-blue-500 hover:underline">Email: dannx@pnt.edu.vn</a> </p> </div> <div> <li class="font-semibold">TS. Long Khanh-Dao Le</li> <p class="pl-6">Bộ môn Kinh tế Y tế, Trường Y tế Công cộng và Y học Dự phòng<br> Đại học Monash, Melbourne, Úc </p> </div> <div> <li class="font-semibold">ThS. Jaithri Ananthapavan</li> <p class="pl-6">Bộ môn Kinh tế Y tế, Trường Phát triển Sức khỏe và Xã hội<br> Đại học Deakin, Geelong, Victoria, Úc </p> </div> <div> <li class="font-semibold">ThS. Phan Danh Na</li> <p class="pl-6">Khoa Quản lí Thể thao<br> Đại học Thể thao Quốc gia Đài Loan, Đài Trung, Đài Loan </p> </div> <div> <li class="font-semibold">PGS. TS. BS. Tăng Kim Hồng</li> <p class="pl-6">Bộ môn Dịch tễ học, Khoa Y tế Công cộng<br> Trường Đại học Y khoa Phạm Ngọc Thạch, TP. Hồ Chí Minh, Việt Nam </p> </div>',
        },
      };
      return data;
    }
  }
}
