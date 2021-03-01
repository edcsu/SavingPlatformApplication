import { Data } from 'popper.js';
import { Action, Reducer } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface MembersState {
    isLoading: boolean;
    startDateIndex?: number;
    members: MembersResponse;
}

export interface MembersResponse {
    pagination: Pagination;
    members: Members[];
}

export interface Pagination {
    page: number;
    itemsPerPage: number;
    totalItems: number;
}

export interface Members {
    id: string;
    dateCreated: Date;
    dateUpdated: Date;
    email: string;
    phoneNumber: string;
    fullName: string;
    birthDate: Date;
    balance: number;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestWeatherForecastsAction {
    type: 'REQUEST_MEMBERS';
    startDateIndex: number;
}

interface ReceiveWeatherForecastsAction {
    type: 'RECEIVE_MEMBERS';
    startDateIndex: number;
    members: Members[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestWeatherForecastsAction | ReceiveWeatherForecastsAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestMembers: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        if (appState && appState.weatherForecasts && startDateIndex !== appState.weatherForecasts.startDateIndex) {
            fetch(`members`)
                .then(response => response.json() as Promise<Members[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_MEMBERS', startDateIndex: startDateIndex, members: data });
                });

            dispatch({ type: 'REQUEST_MEMBERS', startDateIndex: startDateIndex });
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: MembersState = {
    members: {
        pagination: {
            page: 0,
            itemsPerPage: 0,
            totalItems: 0
        },
        members: []
    }, isLoading: false
};

export const reducer: Reducer<MembersState> = (state: MembersState | undefined, incomingAction: Action): MembersState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_MEMBERS':
            return {
                startDateIndex: action.startDateIndex,
                members: state.members,
                isLoading: true
            };
        case 'RECEIVE_MEMBERS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.startDateIndex === state.startDateIndex) {
                return {
                    startDateIndex: action.startDateIndex,
                    members: state.members,
                    isLoading: false
                };
            }
            break;
    }

    return state;
};
