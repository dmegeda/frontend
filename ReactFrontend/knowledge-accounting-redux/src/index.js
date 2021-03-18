import React from 'react';
import ReactDOM from 'react-dom';
import { Route, Switch, Redirect, BrowserRouter as Router } from 'react-router-dom';
import { Provider } from 'react-redux';

import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';

import FooterComponent from './Components/Shared/Footer/FooterComponent';
import HeaderComponent from './Components/Shared/Header/HeaderComponent';
import HomeComponent from './Components/Home/HomeComponent';
import TestComponent from './Components/Test/TestComponent';
import LoginComponent from './Components/Auth/Login/LoginComponent';
import RegistrationComponent from './Components/Auth/Registration/RegistrationComponent';
import StatisticComponent from './Components/Statistic/StatisticComponent';

import { store } from './Redux/Store/index';

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
