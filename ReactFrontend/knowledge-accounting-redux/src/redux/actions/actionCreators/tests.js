import { ActionTypes } from '../actionTypes/testActions';

export const selectTest = (test) => {
    return {
        type: ActionTypes.TEST_SELECTED,
        payload: test
    }
};

export const setTestsList = (tests) => {
    return {
        type: ActionTypes.SET_TEST_LIST,
        payload: tests
    }
}

export const startTesting = (test) => {
    return {
        type: ActionTypes.TESTING_STARTED,
        payload: test
    }
}

export const endTesting = (test) => {
    return {
        type: ActionTypes.TESTING_ENDED,
        payload: test
    }
}



