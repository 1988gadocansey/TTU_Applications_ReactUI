import './components/App.css';
import Home from "./components/Home";
import {BrowserRouter, Route} from 'react-router-dom'
import Form from "./components/forms/Form";
import PictureUpload from "./components/avatar/PictureUpload";
import ResultUpload from "./components/results/ResultUpload";
import PrintPreview from "./components/print/PrintPreview";
import Index from "./components/layouts/Index";
import AuthorizeRoute from './components/api-authorization/AuthorizeRoute';
import ApiAuthorizationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import {ApplicationPaths} from './components/api-authorization/ApiAuthorizationConstants';
import {FetchData} from "./components/FetchData";
import {connect} from "react-redux";
import {Component} from "react";

class App extends Component {

    render() {
        return (

            <div className="App">
                <BrowserRouter>
                    <div>
                        <Index>
                            <Route path="/" exact={true} component={Home}/>
                            <AuthorizeRoute path="/home" exact={true} component={Home}/>
                            <AuthorizeRoute path="/pictureUpload" component={PictureUpload}/>
                            <AuthorizeRoute path="/form/fill" component={Form}/>
                            <AuthorizeRoute path="/resultUpload" component={ResultUpload}/>

                            <AuthorizeRoute path='/fetch-data' component={FetchData}/>
                            <AuthorizeRoute path='/preview' component={PrintPreview}/>
                            <Route path={ApplicationPaths.ApiAuthorizationPrefix}
                                   component={ApiAuthorizationRoutes}/>
                        </Index>
                    </div>
                </BrowserRouter>

            </div>
        );
    }
}

export default App;
