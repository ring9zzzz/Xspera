import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { ProductList } from './components/ProductList';
import { AddingReview } from './components/AddingReview';

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/product-list' component={ProductList} />
                <Route path='/adding-review/:id' component={AddingReview} />
            </Layout>
        );
    }
}