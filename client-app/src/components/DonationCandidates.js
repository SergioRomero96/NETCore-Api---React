import { Button, ButtonGroup, Grid, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, withStyles } from "@material-ui/core";
import { useEffect, useState } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/donationCandidate";
import DonationCandidateForm from "./DonationCandidateForm";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import { useToasts } from "react-toast-notifications";


const styles = theme => ({
    root: {
        "& .MuiTableCell-head": {
            fontSize: "1.25rem"
        }
    },
    paper: {
        margin: theme.spacing(2),
        padding: theme.spacing(2)
    }
})


const DonationCandidates = ({ classes, ...props }) => {
    const { addToast } = useToasts();

    const [currentId, setCurrentId] = useState(0);

    useEffect(() => {
        props.fetchAll();
    }, [])//componentDidMount

    const onDelete = id => {
        if (window.confirm('Are you sure to delete this record?')) {
            props.deleteDCandidate(id, () => addToast("Deleted successfully", { appearance: 'info' }))
        }
    }

    return (
        <Paper className={classes.paper} elevation={3}>
            <Grid container>
                <Grid item md={6}>
                    <DonationCandidateForm {...({ currentId, setCurrentId })} />
                </Grid>
                <Grid item md={6}>
                    <TableContainer>
                        <Table>
                            <TableHead className={classes.root}>
                                <TableRow>
                                    <TableCell>Name</TableCell>
                                    <TableCell>Mobile</TableCell>
                                    <TableCell>Blood Group</TableCell>
                                    <TableCell></TableCell>
                                </TableRow>
                            </TableHead>
                            <TableBody>
                                {
                                    props.list.map((record, index) => {
                                        return (
                                            <TableRow key={index}>
                                                <TableCell>{record.fullName}</TableCell>
                                                <TableCell>{record.mobile}</TableCell>
                                                <TableCell>{record.bloodGroup}</TableCell>
                                                <TableCell>
                                                    <ButtonGroup variant="text">
                                                        <Button onClick={() => { setCurrentId(record.id) }}>
                                                            <EditIcon color="primary" />
                                                        </Button>
                                                        <Button onClick={() => onDelete(record.id)}>
                                                            <DeleteIcon color="secondary" />
                                                        </Button>

                                                    </ButtonGroup>
                                                </TableCell>
                                            </TableRow>
                                        )
                                    })
                                }
                            </TableBody>
                        </Table>
                    </TableContainer>
                </Grid>
            </Grid>
        </Paper>

    );
}

const mapStateToProps = state => ({
    list: state.donationCandidate.list
})

const mapActionToProps = {
    fetchAll: actions.fetchAll,
    deleteDCandidate: actions.deleteDC
}

export default connect(mapStateToProps, mapActionToProps)(withStyles(styles)(DonationCandidates));