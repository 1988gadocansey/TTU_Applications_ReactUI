import { connect } from 'react-redux'
import { setNomineeData } from '../../actions/nominees/NomineesAction'
import UploadPicture from '../../components/nominees/form/upload-picture'
import { getAllElections, getPortfolios } from '../../actions/elections/ElectionAction'

const mapStateToProps = (state) => ({
  nomineeData: state.nominationReducer.nomineeData,
  activeRoles: state.userReducer.activeRoles,
  elections: state.electionReducer.elections,
  portfolios: state.electionReducer.electionPortFolios
})

const mapDispatchToProps = (dispatch) => ({
  setNomineeData: (payload) => dispatch(setNomineeData(payload)),
  getAllElections: (payload) => dispatch(getAllElections(payload)),
  getPortfolios: (payload) => dispatch(getPortfolios(payload)),
})

export default connect(mapStateToProps, mapDispatchToProps)(UploadPicture)
