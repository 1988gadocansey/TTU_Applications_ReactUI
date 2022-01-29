import { connect } from 'react-redux'
import { setNomineeData } from '../../actions/nominees/NomineesAction'
import Vision from '../../components/nominees/form/vision'

const mapStateToProps = (state) => ({
  nomineeData: state.nominationReducer.nomineeData
})

const mapDispatchToProps = (dispatch) => ({
  setNomineeData: (payload) => dispatch(setNomineeData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Vision)
