import {applyMiddleware, createStore} from 'redux'
import {persistStore} from 'redux-persist'
import thunk from 'redux-thunk'
import rootReducer from '../reducers'


const Store = createStore(rootReducer,{},applyMiddleware(thunk))
 

export default Store

