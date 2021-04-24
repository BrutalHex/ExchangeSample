'use strict';

import { Setting } from '../../base/settings';
import { ExchangeThunkDispatch, ExchangeThunkResult } from '../../base/BaseTypes';
import { creatAction } from '../../Types/ActionTypes';
import { Exchange_Rate } from '../../Types/IExchangeRateAction';
import ExchangeRate from './ExchangeRate';

import { Spinner_Change } from '../../Types/ISpinnerChangeAction';
import axios from 'axios';

export function SendCode(code: string): ExchangeThunkResult<void> {
  return (dispatch: ExchangeThunkDispatch) => {
    dispatch(creatAction(Spinner_Change, false));

    let fetchUrl = `${Setting.getApiUrl('ExchangeRate/get')}/${code}`;

    axios({
      method: 'get',
      url: fetchUrl,
    }).then(function (response: any) {
      debugger;
      let result = new ExchangeRate();
      result.baseCurrency = response.data.baseCurrency;
      result.rates = response.data.rates;
      dispatch(creatAction(Spinner_Change, true));
      dispatch(creatAction(Exchange_Rate, result));
    });
  };
}
