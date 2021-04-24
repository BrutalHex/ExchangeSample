import { createReducer } from '../../base/reducerUtils';
import { IExchangeRateAction } from '../../Types/IExchangeRateAction';
import ExchangeRate from '../ExchangeRate/ExchangeRate';

const exchangeRate = (initstate: ExchangeRate, action: IExchangeRateAction): ExchangeRate => {
  return action.payload;
};
const exchangeRateReducer = createReducer(null, {
  Exchange_Rate: exchangeRate,
});
export default exchangeRateReducer;
