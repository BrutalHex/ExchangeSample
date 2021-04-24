import { combineReducers } from 'redux';
import { createBrowserHistory } from 'history';
import { connectRouter } from 'connected-react-router';
import exchangeRateReducer from '../Pages/ExchangeRate/ExchangeRatePageReducer';
import spinnerReducer from '../components/Spinner/spinnerReducer';
import ExchangeRate from '../Pages/ExchangeRate/ExchangeRate';
import { ActoinTypes } from '../Types/ActionTypes';
import { ActionType } from 'typesafe-actions';

export const history = createBrowserHistory();

export type Act = ActionType<ActoinTypes>;

export type RootState = {
  rates: ExchangeRate;
  pending: boolean;
  router: ReturnType<typeof connectRouter>;
};

const rootReducer = combineReducers<RootState, Act>({
  rates: exchangeRateReducer as any,
  pending: spinnerReducer as any,
  router: connectRouter(history) as any,
});

export default rootReducer;
