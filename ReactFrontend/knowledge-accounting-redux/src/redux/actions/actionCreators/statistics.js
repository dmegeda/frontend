import { ActionTypes } from '../actionTypes/statisticActions';

export const setStatisticsList = (statistics) => {
    return {
        type: ActionTypes.SET_STATISTICS_LIST,
        payload: statistics
    }
}

export const addStatistic = (statistic) => {
    return {
        type: ActionTypes.ADD_STATISTIC,
        payload: statistic
    }
};