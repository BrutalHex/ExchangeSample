import React, { FunctionComponent } from 'react';
import * as yup from 'yup';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Formik } from 'formik';
import SpinnerContainer from '../../components/Spinner/Spinner';
import { ExchangeRatePageProps } from './ExchangeRatePageContainer';

const ExchangeRatePage: FunctionComponent<ExchangeRatePageProps> = (
  props: ExchangeRatePageProps
) => {
  const schema = yup.object({
    baseCurrency: yup.string().trim().required('base crypto currency is required'),
  });

  let ratesPreview = [<div key="thisisempty2332">no results</div>];

  if (props.ratesResult != null && props.ratesResult.rates != null) {
    ratesPreview = Object.keys(props.ratesResult.rates).map((property: any, index: number) => {
      return (
        <div className="row" key={`currencyValues_${property}_${index}`}>
          <div className="col-4">{property}</div>
          <div className="col-8">{props.ratesResult.rates[property]}</div>
        </div>
      );
    });
  }

  return (
    <div className="col-12 col-sm-12 col-md-10 col-lg-8  col-xl-8 single-well my-md-5 my-sm-0 py-4 p-md-5 center">
      <div className="row  mt-4">
        <div className="col-12 center title">Exchange preview</div>
        <div className="col-12 center subtitle mt-3">
          enter your crypto currency code based on Coinmarketcap codes.
        </div>
      </div>
      <div className="row  mt-5">
        <SpinnerContainer>
          <Formik
            validationSchema={schema}
            initialValues={{
              baseCurrency: 'btc',
            }}
            validate={(values) => {
              const errors = {};
              return errors;
            }}
            onSubmit={(values) => {
              props.handleSendClick(values.baseCurrency);
            }}
          >
            {({ handleSubmit, handleChange, handleBlur, values, isValid, errors }) => (
              <Form
                noValidate
                onSubmit={(event: React.FormEvent<HTMLFormElement>): void => {
                  event.preventDefault();
                  handleSubmit(event);
                }}
                className="custom-form center col-12 col-sm-11 col-md-8"
              >
                {props.error != null ? (
                  <div className="alert alert-danger" role="alert">
                    {props.error}
                  </div>
                ) : null}
                <Form.Group controlId="validationFormikbaseCurrency">
                  <Form.Label>Crypto three letter code</Form.Label>
                  <Form.Control
                    type="text"
                    name="baseCurrency"
                    className="form-control form-input"
                    value={values.baseCurrency}
                    onChange={handleChange}
                    isInvalid={!!errors.baseCurrency}
                  />
                  <Form.Control.Feedback type="invalid">
                    {errors.baseCurrency}
                  </Form.Control.Feedback>
                </Form.Group>

                <Button variant="primary" type="submit" className="w-100 mt-4">
                  Get the Result
                </Button>
              </Form>
            )}
          </Formik>
        </SpinnerContainer>
      </div>
      <div className="row mt-5 p-4">
        <div className="col-12">{ratesPreview}</div>
      </div>
    </div>
  );
};

export default ExchangeRatePage;
