import './components/App.css';
import Home from "./components/Home";
import {Switch, Route, Link} from "react-router-dom";
import Form from "./components/forms/Form";
import PictureUpload from "./components/avatar/PictureUpload";
import ResultUpload from "./components/results/ResultUpload";
import PrintPreview from "./components/print/PrintPreview";
import Index from "./components/layouts/Index";
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import {ApplicationPaths} from './components/api-authorization/ApiAuthorizationConstants';
import {FetchData} from "./components/FetchData";
import {Component} from "react";
class App extends Component {
    render() {
        return (
            <div className="App">
                <Index>
                    <Route path="/" exact={true} component={Home}/>
                    <AuthorizeRoute path="/Home" exact={true} component={Home}/>
                    <AuthorizeRoute path="/PictureUpload" component={PictureUpload}/>
                    <AuthorizeRoute path="/Form" component={Form}/>
                    <AuthorizeRoute path="/ResultUpload" component={ResultUpload}/>
                    <AuthorizeRoute path='/fetch-data' component={FetchData}/>
                    <AuthorizeRoute path='/Preview' component={PrintPreview}/>
                    <Route path={ApplicationPaths.ApiAuthorizationPrefix} component={ApiAuthorizationRoutes}/>
                </Index>
            </div>
        );
    }
}

export default App;
