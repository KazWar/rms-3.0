<script setup lang="ts">
//* Component imports
import CampaignCard from './components/campaign-card.vue'
import CampaignCardUpcoming from './components/campaign-card-upcoming.vue'
import CampaignCardExpired from './components/campaign-card-expired.vue'
//* Library imports
import { useCampaignStore } from '@/stores'
import { useI18n } from 'vue-i18n'
//* Model imports
import { Campaign } from '@/common/models'

//* Destructure the parameterized getter from the store
const { RequireCampaigns } = useCampaignStore()

//* Explicitly create an i18n instance using the global scope to get the globally set locale
const { locale } = $(useI18n({ useScope: "global" }))

//* Get the campaigns
const campaigns = await RequireCampaigns(String(locale)) as Campaign[]
</script>

<template>
    <template v-for="(campaign, index) in campaigns" :key="index">
        <template v-if="new Date() < campaign.startDate">
            <campaign-card-upcoming v-bind="campaign"/>
        </template>
        <template v-else-if="new Date() > campaign.startDate && new Date() < campaign.endDate">
            <campaign-card v-bind="campaign"/>
        </template>
        <template v-else-if="new Date() > campaign.endDate">
            <campaign-card-expired v-bind="campaign"/>
        </template>
    </template>
</template>

<style scoped lang="scss">
.campaign-card{
    background: #f0f0f0;
    margin-top: 20px;

    &:hover{
        background: #e4e4e4;
    }
}
</style>