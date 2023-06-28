import { makeAutoObservable, runInAction } from "mobx";
import { User, UserFormValues } from "../models/user";
import agent from "../api/agent";
import { store } from "./store";
import { router } from "../router/Routes";

export default class UserStore {
    user: User | null = null;

    constructor() {
        makeAutoObservable(this)
    }

    get isLoggedIn() {
        return !!this.user;
    }

    login =async (cread:UserFormValues) => {
        try {
            const user = await agent.Account.login(cread);
            store.commonStore.setToken(user.token);
            runInAction(() => this.user = user);
            router.navigate('/activities')
            store.modalStore.clsoeModal();
        } catch (error) {
            throw error;
        }
    }

    register =async (reg :UserFormValues) => {
        try {
            const user = await agent.Account.register(reg);
            store.commonStore.setToken(user.token);
            runInAction(() => this.user = user);
            router.navigate('/activities')
            store.modalStore.clsoeModal();
        } catch (error) {
            throw error;
        }
    }

    logout = () => {
        store.commonStore.setToken(null);
        this.user = null;
        router.navigate('/');
    }

    getUser = async () => {
        try {
            const user = await agent.Account.current();
            runInAction(() => {
                console.log(user);
                this.user = user
            });
        } catch (error) {
            console.log(error);
        }
    }
}

