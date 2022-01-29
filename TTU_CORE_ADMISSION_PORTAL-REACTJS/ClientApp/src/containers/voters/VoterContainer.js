import { connect } from 'react-redux'
import Voter from '../../components/voters'
import { getAllVoters, setVoterData } from '../../actions/voters/VoterAction'

const mapStateToProps = (state) => ({
  voters: state.voterReducer.voters,
})

const mapDispatchToProps = (dispatch) => ({
  getAllVoters: () => getAllVoters(),
  setVoterData: (payload) => dispatch(setVoterData(payload))
})

export default connect(mapStateToProps, mapDispatchToProps)(Voter)
