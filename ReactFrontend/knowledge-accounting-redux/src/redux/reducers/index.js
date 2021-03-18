import { combineReducers } from 'redux';
import testsReducer from './testsReducer';

const reducers = combineReducers({
    tests: testsReducer
});

export default reducers;