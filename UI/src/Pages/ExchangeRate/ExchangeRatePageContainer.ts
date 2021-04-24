import { connect, ConnectedProps } from 'react-redux';
import { ExchangeThunkDispatch } from '../../base/BaseTypes';
import { RootState } from '../../base/reducers';
import ExchangeRatePage from './ExchangeRatePage';
import { SendCode } from './ExchangeRatePageAction';
import ExchangeRate from './ExchangeRate';

const mapStateToProps = (state: RootState) => {
  return { ratesResult: state.rates };
};

const mapDispatchToProps = (dispatch: ExchangeThunkDispatch) => {
  return {
    handleSendClick: (code: string) => {
      dispatch(SendCode(code));
    },
  };
};

const connector = connect(mapStateToProps, mapDispatchToProps);

type PropsFromRedux = ConnectedProps<typeof connector>;

export interface ExchangeRatePageProps extends PropsFromRedux {
  error: string | null;
  ratesResult: ExchangeRate;
  handleSendClick(code: string): void;
}

const exchangeRatePageContainer = connector(ExchangeRatePage);
export default exchangeRatePageContainer;
