import { connect } from 'react-redux'
import {setFormData, updateForm} from '../actions/forms/FormsAction'
import ApplicationForm from '../components/forms/ApplicationForm'

const mapStateToProps = (state) => ({
    bioData: state.applicationform.formContent
})

const mapDispatchToProps = (dispatch) => ({
    setFormData: (payload) => dispatch(setFormData(payload)),
    updateForm: (payload) => dispatch(updateForm(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(ApplicationForm)
