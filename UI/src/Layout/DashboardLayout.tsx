/* eslint-disable no-useless-rename */
/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
import React, { Component, FunctionComponent } from 'react';
import { Route } from 'react-router-dom';
import '../Pages/style/main.scss';
import Footer from '../Pages/Footer';
import Navbar from 'react-bootstrap/Navbar';
import NavbarToggle from 'react-bootstrap/NavbarToggle';
import NavbarCollapse from 'react-bootstrap/NavbarCollapse';
import NavbarBrand from 'react-bootstrap/NavbarBrand';
import Nav from 'react-bootstrap/Nav';
import NavLink from 'react-bootstrap/NavLink';


export const DashboardLayout: FunctionComponent<any> = ({ children }) => (
  <div className="container-fluid dashboard">
   <div className="row menu-bar">
      <Navbar bg="transparent" collapseOnSelect expand="lg" className="w-100">
        <NavbarToggle aria-controls="basic-navbar-nav" />
        <NavbarBrand
          href="#"
          className="col-9 col-sm-3 col-lg-3 col-xl-2 pl-lg-3 ml-lg-3 ml-md-1 ml-xl-5 pl-xl-5 navbar-brand 
                        navbar-brand mx-sm-auto align-self-sm-center navbar-brand navbar-brand navbar-brand"
        >
          <img
            src={`${process.env.PUBLIC_URL}/logo.svg`}
            className="d-inline-block"
            width="40" height="40"
          /><strong className="logo-text">Exchange</strong>
       
        </NavbarBrand>

        <NavbarCollapse
          className="col-12 col-sm-5 col-lg-6 
                        justify-content-end ml-md-5 pl-md-5 ml-lg-2 navbar-collapse collapse"
          id="basic-navbar-nav"
        >
          <Nav className="">
            <NavLink className="mr-md-4" href="#">
              Home
            </NavLink>
          </Nav>
        </NavbarCollapse>
      
      </Navbar>
    </div>
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
