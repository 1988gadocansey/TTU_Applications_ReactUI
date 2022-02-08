import { connect } from 'react-redux'
import Dashboard from '../components/dashboard/Dashboard'
import { getFormData } from '../actions/user/UsersAction'

const mapStateToProps = (state) => ({
    users: state.people.loggedInUser
})

const mapDispatchToProps = (dispatch) => ({
    getFormData: (payload) => dispatch(getFormData(payload)),
})

export default connect(mapStateToProps, mapDispatchToProps)(Dashboard)
