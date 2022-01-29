import { connect } from 'react-redux'
import { getVotingResults } from '../../actions/voters/VoterAction'
import Results from '../../components/voting/results'

const mapStateToProps = (state) => ({
  electionResults: state.voterReducer.electionResults,
})

const mapDispatchToProps = (dispatch) => ({
  getVotingResults: (payload) => dispatch(getVotingResults(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Results)
