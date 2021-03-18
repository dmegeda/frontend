import { combineReducers } from 'redux';
import testsReducer from './testsReducer';
import statisticReducer from './statisticReducer';

const reducers = combineReducers({
    tests: testsReducer,
    statistics: statisticReducer
});

export default reducers;