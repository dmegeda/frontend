import React from 'react';
import ReactDOM from 'react-dom';
import { Route, Switch, Redirect, BrowserRouter as Router } from 'react-router-dom';
import { Provider } from 'react-redux';

import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';

import FooterComponent from './components/shared/footer/footerComponent';
import HeaderComponent from './components/shared/header/headerComponent';
import HomeComponent from './components/home/homeComponent';
import TestComponent from './components/test/testComponent';
import LoginComponent from './components/auth/login/loginComponent';
import RegistrationComponent from './components/auth/registration/registrationComponent';
import StatisticComponent from './components/statistic/statisticComponent';

import { store } from './redux/store/index';

ReactDOM.render(
  <Provider store={store}>
    <Router>
        <HeaderComponent />
        <Switch>
              <Route exact path="/" component={HomeComponent} />
              <Route exact path="/home"><Redirect to="/" /></Route>
              <Route exact path="/test/:id" component={TestComponent}></Route>
              <Route exact path="/login" component={LoginComponent}></Route>
              <Route exact path="/register" component={RegistrationComponent}></Route>
              <Route exact path="/statistic" component={StatisticComponent}></Route>
              <Route component={HomeComponent} />
            </Switch>
        <FooterComponent />
      </Router>
  </Provider>,
  document.getElementById('root')
);
