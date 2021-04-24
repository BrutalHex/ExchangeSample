import React from 'react';

import { BrowserRouter as Router, Route, Redirect, Switch } from 'react-router-dom';

/** Layouts **/
import SharedLayout from './Layout/SharedLayout';
import { DashboardLayoutRoute } from './Layout/DashboardLayout';

import exchangeRatePageContainer from './Pages/ExchangeRate/ExchangeRatePageContainer';

function App() {
  return (
    <SharedLayout>
      <Switch>
        <Route exact path="/">
          <Redirect to="/rates" />
        </Route>

        <Route path={['/rates']}>
          <DashboardLayoutRoute>
            <Switch>
              <Route path="/rates" component={exchangeRatePageContainer} />
            </Switch>
          </DashboardLayoutRoute>
        </Route>
      </Switch>
    </SharedLayout>
  );
}

export default App;
