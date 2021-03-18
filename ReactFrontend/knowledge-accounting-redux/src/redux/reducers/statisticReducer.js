import { ActionTypes } from '../actions/actionTypes/statisticActions';

const initialState = {
    statisticList: [],
    statistic: {}
}

export default function (state = initialState, action) {
    switch (action.type) {
        case ActionTypes.SET_STATISTICS_LIST: {
            return {...state, statisticList: action.payload}
        }
        case ActionTypes.ADD_STATISTIC: {
            return { ...state, statistic: action.payload }
        }
        default:
            return state;
    }
}