/* eslint-disable no-useless-rename */
/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
import React, { Component, FunctionComponent } from 'react';
import { Route } from 'react-router-dom';
import '../Pages/style/main.scss';
import Footer from '../Pages/Footer';

export const DashboardLayout: FunctionComponent<any> = ({ children }) => (
  <div className="container-fluid dashboard">
    <div className="row children-area px-2 py-4 p-md-4 d-flex">{children}</div>
    <Footer />
  </div>
);

export const DashboardLayoutRoute: FunctionComponent<any> = ({ Component: Component, ...rest }) => {
  return (
    <DashboardLayout>
      <Route {...rest} render={(matchProps) => <Component {...matchProps} />} />{' '}
    </DashboardLayout>
  );
};
export default DashboardLayoutRoute;
