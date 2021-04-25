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
          <div className="col-11 rate-vals border-bottom border-bottom-dashed">
            <span className="material-icons">payments</span>
            <span className="title badge bg-info">{property}</span>
            <span className="value">{props.ratesResult.rates[property]}</span>
          </div>
        </div>
      );
    });
  }

  return (
    <div className="col-12">
      <SpinnerContainer>
        <div className="row  mt-5">
          <div className="col-12 col-sm-4">
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
                  className=" col-12 col-sm-11 col-md-8"
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

                  <Button variant="primary" type="submit" className="w-100 mt-1">
                    Get the Result
                  </Button>
                </Form>
              )}
            </Formik>
          </div>
          <div className="col-12 col-sm-6 rate-box">{ratesPreview}</div>
        </div>
      </SpinnerContainer>
    </div>
  );
};

export default ExchangeRatePage;
