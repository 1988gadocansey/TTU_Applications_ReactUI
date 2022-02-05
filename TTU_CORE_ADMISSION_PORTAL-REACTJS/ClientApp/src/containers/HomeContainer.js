import { connect } from 'react-redux'
import {Counter} from "../components/Counter"
import getUser from '../actions/user/UsersAction'

const mapStateToProps = (state) => ({
    getUser: state.userReducer.userDetail
})

const mapDispatchToProps = (dispatch) => ({
    getUsers: (payload) => dispatch(getUser(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Counter)
