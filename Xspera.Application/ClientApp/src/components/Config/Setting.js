import { Component } from 'react';

export class Setting extends Component {
    static displayName = Setting.name;
    static rootAPI = "https://localhost:44342/xpera/api";
    static GetProduct(id)
    {
        return "/getprodbyid?productId=" + id+ "";
    }
    static GetProductByBrand(id) {
        if (id) {
           return "?brandId=" + id + "";
        }
        return "";
    }
    static AddReview = "/addingreview";

    static formatDate(string) {
        var options = { year: 'numeric', month: 'long', day: 'numeric' };
        return new Date(string).toLocaleDateString([], options);
    }
}