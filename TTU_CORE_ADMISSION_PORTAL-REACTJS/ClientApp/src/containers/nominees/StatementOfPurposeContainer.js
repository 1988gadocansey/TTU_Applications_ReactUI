import { connect } from 'react-redux'
import { setNomineeData } from '../../actions/nominees/NomineesAction'
import StatementOfPurpose from '../../components/nominees/form/statement-of-purpose'

const mapStateToProps = (state) => ({
  nomineeData: state.nominationReducer.nomineeData
})

const mapDispatchToProps = (dispatch) => ({
  setNomineeData: (payload) => dispatch(setNomineeData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(StatementOfPurpose)
