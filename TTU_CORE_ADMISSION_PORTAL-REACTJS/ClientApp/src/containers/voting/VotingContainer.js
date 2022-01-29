import { connect } from 'react-redux'
import Voting from '../../components/voting'
import { getVotingDetail } from '../../actions/voters/VoterAction'

const mapStateToProps = (state) => ({
  electionDetail: state.voterReducer.electionDetail,
})

const mapDispatchToProps = (dispatch) => ({
  getVotingDetail: (payload) => dispatch(getVotingDetail(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Voting)
