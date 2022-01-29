import { connect } from 'react-redux'
import { setNomineeData, updateNomineeInfo } from '../../actions/nominees/NomineesAction'
import ApplicationForm from '../../components/nominees/form/application-form'

const mapStateToProps = (state) => ({
  nomineeData: state.nominationReducer.nomineeData
})

const mapDispatchToProps = (dispatch) => ({
  setNomineeData: (payload) => dispatch(setNomineeData(payload)),
  updateNomineeInfo: (payload) => dispatch(updateNomineeInfo(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(ApplicationForm)
