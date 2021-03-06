import {applyMiddleware, createStore} from 'redux'
import {persistStore} from 'redux-persist'
import thunk from 'redux-thunk'
import rootReducer from '../reducers'
import { composeWithDevTools } from 'redux-devtools-extension'
const initialState = {}
const middleware = [thunk]

const Store = createStore(rootReducer,initialState,composeWithDevTools(applyMiddleware(...middleware)))
export default Store

