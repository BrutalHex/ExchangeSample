export class Setting {
  static mainUrl: string = 'http://localhost:5001/api/';
  static getApiUrl = (address: string): string => Setting.mainUrl + address;
}
export default Setting;
