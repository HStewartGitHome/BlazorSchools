import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { PerfData } from './components/PerfData';
import { SchoolData } from './components/SchoolData';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/perf-data' component={PerfData} />
        <Route path='/school-data' component={SchoolData} />
      </Layout>
    );
  }
}
