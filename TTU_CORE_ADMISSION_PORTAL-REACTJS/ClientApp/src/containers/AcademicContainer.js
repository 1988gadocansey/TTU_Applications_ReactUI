import { connect } from 'react-redux'
import {setFormData, updateForm} from '../actions/forms/FormsAction'
import SecondStep from "../components/forms/SecondStep";

const mapStateToProps = (state) => ({
    bioData: state.applicationform.formContent
})

const mapDispatchToProps = (dispatch) => ({
    setFormData: (payload) => dispatch(setFormData(payload)),
    updateForm: (payload) => dispatch(updateForm(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(SecondStep)
