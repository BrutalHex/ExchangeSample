/* eslint-disable camelcase */
import { IGeneralAction } from './IGeneralAction';
import ExchangeRate from '../Pages/ExchangeRate/ExchangeRate';

export const Exchange_Rate = 'Exchange_Rate';

export interface IExchangeRateAction extends IGeneralAction<typeof Exchange_Rate, ExchangeRate> {}
